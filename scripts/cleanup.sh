echo "Starting Cleanup..."
echo "Shutting Down Containers and Volumes ⛔"
docker-compose -f docker/docker-compose.yml down
docker volume rm docker_quizz-data
echo "Cleanup Completed! ✅"