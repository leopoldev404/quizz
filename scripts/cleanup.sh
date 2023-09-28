echo "Starting Cleanup..."
docker-compose -f docker/docker-compose.yml down
docker volume rm docker_quizz-data
echo "Clean Completed!"